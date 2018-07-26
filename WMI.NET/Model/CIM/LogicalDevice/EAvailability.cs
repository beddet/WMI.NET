namespace WMI.NET.Model.CIM.LogicalDevice
{
	public enum EAvailability : ushort
	{
		Other = 1,
		Unknown = 2,
		Running_FullPower = 3,
		Warning = 4,
		In_Test = 5,
		Not_Applicable = 6,
		Power_Off = 7,
		Off_Line = 8,
		Off_Duty = 9,
		Degraded = 10,
		Not_Installed = 11,
		Install_Error = 12,
		/// <summary>
		/// The device is known to be in a power save mode, but its exact status is unknown.
		/// </summary>
		Power_Save_Unknown = 13,
		/// <summary>
		/// The device is in a power save state but still functioning, and may exhibit degraded performance.
		/// </summary>
		Power_Save_Low_Power_Mode = 14,
		/// <summary>
		/// The device is not functioning but could be brought to full power quickly.
		/// </summary>
		Power_Save_Standby = 15,
		Power_Cycle = 16,
		/// <summary>
		/// The device is in a warning state, though also in a power save mode.
		/// </summary>
		Power_Save_Warning = 17
	}
}