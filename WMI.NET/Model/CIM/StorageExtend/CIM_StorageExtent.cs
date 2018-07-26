using System;
using WMI.NET.Model.CIM.LogicalDevice;
using WMI.NET.Model.Shared.Attributes;

namespace WMI.NET.Model.CIM.StorageExtend
{
	/// <summary>
	/// The CIM_StorageExtent class represents the capabilities and management of the various media that exist to store data and allow data retrieval. This parent class can represent the various components of RAID (hardware or software) or a raw logical extent on top of physical media.
	/// </summary>
	[WMIClassName("CIM_StorageExtent", true)]
	public class CIM_StorageExtent : CIM_LogicalDevice
	{
		/// <summary>
		/// Describes the read/write properties of the media.
		/// /// <see cref="AccessValue"/>
		/// </summary>
		public ushort Access { get; set; }
		/// <summary>
		/// Size, in bytes, of the blocks that form the storage extent. If variable block size, then the maximum block size, in bytes, should be specified. If the block size is unknown, or if a block concept is not valid (for example, for aggregate extents, memory, or logical disks), enter a 1 (one).
		/// </summary>
		public ulong BlockSize { get; set; }
		/// <summary>
		/// Free-form string that describes the type of error detection and correction supported by the storage extent.
		/// </summary>
		public string ErrorMethodology { get; set; }
		/// <summary>
		/// Number of consecutive blocks, each block the size of the value contained in the BlockSize property, that form the storage extent. Total size of the storage extent can be calculated by multiplying the value of the BlockSize property by the value of this property. If the value of BlockSize is 1 (one), this property is the total size of the storage extent.
		/// </summary>
		public ulong NumberOfBlocks { get; set; }
		/// <summary>
		/// Free form string that describes the media and its use.
		/// </summary>
		public string Purpose { get; set; }
		/// <summary>
		/// Describes the read/write properties of the media.
		/// </summary>
		public EAccess AccessValue
		{
			get { return (EAccess) Access; }
		}
	}
}