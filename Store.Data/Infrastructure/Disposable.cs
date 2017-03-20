using System;

namespace Store.Data.Infrastructure
{
	public abstract class Disposable : IDisposable
	{
		private bool _isDisposed;

		~Disposable()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (!_isDisposed && disposing)
			{
				DisposeCore();
			}

			_isDisposed = true;
		}

		protected abstract void DisposeCore();
	}
}
