using System;
using Plugin.IPAddress.Abstractions;

namespace IPAddress.Plugin
{
	public static class CrossIPAddress
	{
		static Lazy<IIPAddressFinder> Instance = new Lazy<IIPAddressFinder>(() => CreateIPAddressFinder(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

		/// <summary>
		/// Current settings to use
		/// </summary>
		public static IIPAddressFinder Current
		{
			get
			{
				var result = Instance.Value;
				if (ret == null)
				{
					throw NotImplementedInReferenceAssembly();
				}
				return result;
			}
		}

		static IIPAddressFinder CreateIPAddressFinder()
		{
#if PORTABLE
            return null;
#else
			return new IPAddressFinder();
#endif
		}

		internal static Exception NotImplementedInReferenceAssembly()
		{
			return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the Plugin.IPAddress NuGet package from your main application project in order to reference the platform-specific implementation.");
		}
	}
}
