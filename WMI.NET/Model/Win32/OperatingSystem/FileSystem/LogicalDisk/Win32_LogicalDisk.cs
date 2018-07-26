using WMI.NET.Model.CIM;
using WMI.NET.Model.Shared;
using WMI.NET.Model.Shared.Attributes;

namespace WMI.NET.Model.Win32.OperatingSystem.FileSystem.LogicalDisk
{
	/// <summary>
	/// The Win32_LogicalDisk WMI class represents a data source that resolves to an actual local storage device on a computer system running Windows.
	/// </summary>
	[WMIClassName("Win32_LogicalDisk", true)]
	public class Win32_LogicalDisk : CIM_LogicalDisk
	{
		/// <summary>
		/// If True, the logical volume exists as a single compressed entity, such as a DoubleSpace volume. If file based compression is supported, such as on NTFS, this property is False.
		/// </summary>
		public bool Compressed { get; set; }
		/// <summary>
		/// Numeric value that corresponds to the type of disk drive this logical disk represents.
		/// <see cref="DriveTypeValue"/>
		/// </summary>
		public uint DriveType { get; set; }
		/// <summary>
		/// File system on the logical disk.
		/// Example: "NTFS"
		/// </summary>
		public string FileSystem { get; set; }
		/// <summary>
		/// Maximum length of a filename component supported by the Windows drive. A filename component is that portion of a filename between backslashes. The value can be used to indicate that long names are supported by the specified file system. For example, for a FAT file system supporting long names, the function stores the value 255, rather than the previous 8.3 indicator. Long names can also be supported on systems that use the NTFS file system.
		/// Example: 255
		/// </summary>
		public uint MaximumComponentLength { get; set; }
		/// <summary>
		/// Type of media currently present in the logical drive. This value will be one of the values of the MEDIA_TYPE enumeration defined in Winioctl.h. The value may not be exact for removable drives if currently there is no media in the drive.
		/// </summary>
		public uint MediaType { get; set; }
		/// <summary>
		/// Network path to the logical device.
		/// </summary>
		public string ProviderName { get; set; }
		/// <summary>
		/// Indicates that quota management is not enabled (TRUE) on this system.
		/// Windows 2000, Windows NT 4.0, and Windows Me/98/95:  This property is not available.
		/// </summary>
		public bool QuotasDisabled { get; set; }
		/// <summary>
		/// Indicates that the quota management was used but has been disabled (True). Incomplete refers to the information left in the file system after quota management was disabled.
		/// Windows 2000, Windows NT 4.0, and Windows Me/98/95:  This property is not available.
		/// </summary>
		public bool QuotasIncomplete { get; set; }
		/// <summary>
		/// If True, indicates that the file system is in the active process of compiling information and setting the disk up for quota management.
		/// Windows 2000, Windows NT 4.0, and Windows Me/98/95:  This property is not available.
		/// </summary>
		public bool QuotasRebuilding { get; set; }
		/// <summary>
		/// If True, this volume supports disk quotas.
		/// Windows 2000, Windows NT 4.0, and Windows Me/98/95:  This property is not available.
		/// </summary>
		public bool SupportsDiskQuotas { get; set; }
		/// <summary>
		/// If True, the logical disk partition supports file-based compression, such as is the case with the NTFS file system. This property is False when the Compressed property is True.
		/// </summary>
		public bool SupportsFileBasedCompression { get; set; }
		/// <summary>
		/// If True, the disk requires ChkDsk to be run at the next restart. This property is only applicable to those instances of logical disk that represent a physical disk in the machine. It is not applicable to mapped logical drives.
		/// Windows 2000, Windows NT 4.0, and Windows Me/98/95:  This property is not available.
		/// </summary>
		public bool VolumeDirty { get; set; }
		/// <summary>
		/// Volume name of the logical disk.
		/// Constraints: Maximum 32 characters.
		/// </summary>
		public string VolumeName { get; set; }
		/// <summary>
		/// Volume serial number of the logical disk.
		/// Constraints: Maximum 11 characters.
		/// Example: "A8C3-D032"
		/// </summary>
		public string VolumeSerialNumber { get; set; }

		/// <summary>
		/// Numeric value that corresponds to the type of disk drive this logical disk represents.
		/// </summary>
		public EDriveType DriveTypeValue
		{
			get { return (EDriveType)DriveType; }
		}

		public override string ToString()
		{
			return string.Format("DriveType\t{0}\nFreeSpace\t{1}\nVolumeName\t{2}", DriveTypeValue, FreeSpace, VolumeName);
		}
	}
}