using System;
using Foundation;
using System.Runtime.InteropServices;

namespace Google.TagManager
{
	public partial class ContainerOpener
	{
		[Obsolete ("Use the OpenContainer that recieves a notifier in params.")]
		public static IContainerFuture OpenContainer (string containerId, Manager tagManager, OpenType openType, double? timeout)
		{
			IntPtr pDouble = IntPtr.Zero;

			if (timeout != null) {
				double[] array = { timeout.GetValueOrDefault () };
				pDouble = Marshal.AllocHGlobal (IntPtr.Size * array.Length);
				Marshal.Copy (array, 0, pDouble, array.Length);
			}

			var result = _OpenContainer (containerId, tagManager, openType, pDouble);
			Marshal.FreeHGlobal (pDouble);

			return result;
		}

		public unsafe static void OpenContainer (string containerId, Manager tagManager, OpenType openType, double? timeout, IContainerOpenerNotifier notifier)
		{
			IntPtr pDouble = IntPtr.Zero;

			if (timeout != null) {
				double[] array = { timeout.GetValueOrDefault () };
				pDouble = Marshal.AllocHGlobal (IntPtr.Size * array.Length);
				Marshal.Copy (array, 0, pDouble, array.Length);
			}

			_OpenContainer (containerId, tagManager, openType, pDouble, notifier);

			Marshal.FreeHGlobal (pDouble);
		}
	}
}
