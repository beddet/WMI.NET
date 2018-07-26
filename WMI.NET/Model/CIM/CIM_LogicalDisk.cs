using WMI.NET.Model.CIM.StorageExtend;
using WMI.NET.Model.Shared.Attributes;

namespace WMI.NET.Model.CIM
{
	/// <summary>
	/// The CIM_LogicalDisk class represents a contiguous range of logical blocks that is identifiable by a file system through the disk's DeviceID (key) field. For example, in a Windows environment, the DeviceID field contains a drive letter; in a UNIX environment, it contains the access path; and in a NetWare environment, it contains the volume name.
	/// </summary>
	[WMIClassName("CIM_LogicalDisk", true)]
	public class CIM_LogicalDisk : CIM_StorageExtent
	{
		/// <summary>
		/// Available free space, in bytes, on the logical disk.
		/// </summary>
		public ulong FreeSpace { get; set; }
		/// <summary>
		/// Size of the logical disk, in bytes.
		/// </summary>
		public ulong Size { get; set; }
	}
}