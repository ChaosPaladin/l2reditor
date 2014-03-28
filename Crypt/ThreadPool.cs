using System.Collections.Generic;
using System.Threading;

namespace L2REditor.Engine {
	public class ThreadPool {
		private readonly LinkedList<Pooled> taskList = new LinkedList<Pooled>(); 
		private readonly object LOCK = new object();
		private Thread[] threads;
		private bool shutdown = false;
		public ThreadPool(int threadsCount) {
			threads = new Thread[threadsCount];
			for (int i = 0; i < threadsCount; i++) {
				threads[i] = new Thread(th);
				threads[i].Start();
			}
		}

		public void addTask(ThreadStart ts, int delay) {
			lock(LOCK) {
				taskList.AddLast(new Pooled {WAIT = delay, TASK = ts});
			}
		}

		public void close() {
			shutdown = true;
			new Thread(new ThreadStart(delegate {
				Thread.Sleep(5000);
				for (int i = 0; i < threads.Length; i++) {
					if(threads[i].IsAlive)
						threads[i].Interrupt();
				}
			})).Start();
		}

		private class Pooled {
			public int WAIT;
			public ThreadStart TASK;
		}

		private void th() {
			while (!shutdown) {
				Thread.Sleep(1000);

				if (taskList.Count == 0)
					continue;

				Pooled pooled;
				lock (LOCK) {
					pooled = taskList.First.Value;
					if (pooled == null)
						continue;
					taskList.RemoveFirst();
				}

				ThreadStart ts = pooled.TASK;
				if(pooled.WAIT > 0)
					Thread.Sleep(pooled.WAIT);
				ts.Invoke();
			}
		}
	}
}
