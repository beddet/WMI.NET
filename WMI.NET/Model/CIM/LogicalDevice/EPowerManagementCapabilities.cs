namespace WMI.NET.Model.CIM.LogicalDevice
{
	public enum EPowerManagementCapabilities
	{
		Unknown = 0,
		Not_Supported = 1,
		Disabled = 2,
		/// <summary>
		/// The power management features are currently enabled but the exact feature set is unknown or the information is unavailable.
		/// </summary>
		Enabled = 3,
		/// <summary>
		/// The device can change its power state based on usage or other criteria.
		/// </summary>
		Power_Saving_Modes_Entered_Automatically = 4,
		/// <summary>
		/// The SetPowerState method is supported. This method is found on the parent CIM_LogicalDevice class and can be implemented. For more information, see Designing Managed Object Format (MOF) Classes.
		/// </summary>
		Power_State_Settable = 5,
		/// <summary>
		/// The SetPowerState method can be invoked with the PowerState parameter set to 5 ("Power Cycle").
		/// </summary>
		Power_Cycling_Supported = 6,
		/// <summary>
		/// The SetPowerState method can be invoked with the PowerStateparameter set to 5 ("Power Cycle") and Time set to a specific date and time, or interval, for power-on.
		/// </summary>
		Timed_Power_On_Supported = 7

	}
}