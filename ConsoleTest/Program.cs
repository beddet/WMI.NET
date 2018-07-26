using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using WMI.NET;
using WMI.NET.Model.Win32.OperatingSystem.FileSystem.LogicalDisk;
using WMI.NET.QueryProvider;

namespace ConsoleTest
{
	class Program
	{
		static void Main()
		{
			IWMIQueryProvider[] queryProviders = new IWMIQueryProvider[]
				{
					new LocalWMIQueryProvider(),
 					new RemoteWMIQueryProvider(ManagementScopeFactory.CreateScope(new Credentials("Administrator", Secret.Password), "10.0.1.192")), 
				};

			foreach (var queryProvider in queryProviders)
			{
				IEnumerable<Win32_LogicalDisk> localDiscs = queryProvider.GetObjects<Win32_LogicalDisk>(x => x.DriveTypeValue == EDriveType.LocalDisk);
				foreach (var disk in localDiscs)
				{
					Console.WriteLine(disk.Name + "\t" + disk.FreeSpace / 1073741824 + " gb free space");

				}
			}


			//IEnumerable<Win32_LogicalDisk> items = LocalWMIQueryProvider.GetObjects<Win32_LogicalDisk>(x => x.DriveTypeValue == EDriveType.LocalDisk);

			//ManagementObjectSearcher searcher = new ManagementObjectSearcher(new ObjectQuery("select * from Win32_LogicalDisk"));
			//ManagementObjectCollection moc = searcher.Get();

			//foreach (ManagementBaseObject v in moc)
			//{
			//    Console.WriteLine(v["Caption"] + "" + v["VolumeName"] + "(" + v["DriveType"] + ")->\t" + v["FreeSpace"]);
			//}

			//foreach (var item in items)
			//{
			//    Console.WriteLine(item + "\n");
			//}

			Console.WriteLine("done");
			Console.ReadKey();
			
		}
	}
}