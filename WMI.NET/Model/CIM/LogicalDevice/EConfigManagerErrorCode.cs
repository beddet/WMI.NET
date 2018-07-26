namespace WMI.NET.Model.CIM.LogicalDevice
{
	public enum EConfigManagerErrorCode : ushort
	{
		/// <summary>
		/// Device is working properly.
		/// </summary>
		Working = 0,
		/// <summary>
		/// Device is not configured correctly.
		/// </summary>
		Not_Configured_Correctly = 1,
		/// <summary>
		/// Windows cannot load the driver for this device.
		/// </summary>
		Cannot_Load_Driver = 2,
		/// <summary>
		/// Driver for this device might be corrupted, or the system may be low on memory or other resources.
		/// </summary>
		Driver_May_Be_Corrupt = 3,
		/// <summary>
		/// Device is not working properly. One of its drivers or the registry might be corrupted.
		/// </summary>
		Device_Not_Working_Properly = 4,
		/// <summary>
		/// Driver for the device requires a resource that Windows cannot manage.
		/// </summary>
		Requires_Resource = 5,
		/// <summary>
		/// Boot configuration for the device conflicts with other devices.
		/// </summary>
		Boot_Configuration_Conflict = 6,
		/// <summary>
		/// Cannot filter.
		/// </summary>
		Cannot_Filter = 7,
		/// <summary>
		/// Driver loader for the device is missing.
		/// </summary>
		Missing_Loaded_Driver = 8,
		/// <summary>
		/// Device is not working properly; the controlling firmware is incorrectly reporting the resources for the device.
		/// </summary>
		Firmware_Incorrectly_Reporting = 9,
		/// <summary>
		/// Device cannot start.
		/// </summary>
		Cannot_Start = 10,
		/// <summary>
		/// Device failed.
		/// </summary>
		Device_Failed = 11,
		/// <summary>
		/// Device cannot find enough free resources to use.
		/// </summary>
		Cannot_Find_Free_Resources = 12,
		/// <summary>
		/// Windows cannot verify the device's resources.
		/// </summary>
		Cannot_Verify_Resources = 13,
		/// <summary>
		/// Device cannot work properly until the computer is restarted.
		/// </summary>
		Device_Requires_Restart = 14,
		/// <summary>
		/// Device is not working properly due to a possible re-enumeration problem.
		/// </summary>
		Device_Is_Not_Working_Properly = 15,
		/// <summary>
		/// Windows cannot identify all of the resources that the device uses.
		/// </summary>
		Cannot_Identify_Resources = 16,
		/// <summary>
		/// Device is requesting an unknown resource type.
		/// </summary>
		Device_Requests_Unknown_Resource = 17,
		/// <summary>
		/// Device drivers must be reinstalled.
		/// </summary>
		Drivers_Must_Be_Reinstalled = 18,
		/// <summary>
		/// Failure using the VxD loader.
		/// </summary>
		Failure_Using_VxD_Loader = 19,
		/// <summary>
		/// Registry might be corrupted.
		/// </summary>
		Registry_Might_Be_Corrupted = 20,
		/// <summary>
		/// System failure. If changing the device driver is ineffective, see the hardware documentation. Windows is removing the device.
		/// </summary>
		System_Failure_Change_Device_Driver_Device_Will_Be_Removed = 21,
		/// <summary>
		/// Device is disabled.
		/// </summary>
		Disabled_Device = 22,
		/// <summary>
		/// System failure. If changing the device driver is ineffective, see the hardware documentation.
		/// </summary>
		System_Failure_Change_Device_Driver = 23,
		/// <summary>
		/// Device is not present, not working properly, or does not have all of its drivers installed.
		/// </summary>
		Device_Is_Not_Present = 24,
		/// <summary>
		/// Windows is still setting up the device.
		/// </summary>
		Still_Setting_Up_Device = 25,
		/// <summary>
		/// Windows is still setting up the device.
		/// </summary>
		Still_Settingup_Device = 26,
		/// <summary>
		/// Device does not have valid log configuration.
		/// </summary>
		Invalid_Log_Configuration = 27,
		/// <summary>
		/// Device drivers are not installed.
		/// </summary>
		Drivers_Not_Installed = 28,
		/// <summary>
		/// Device is disabled; the device firmware did not provide the required resources.
		/// </summary>
		Disabled_Devide_Unprovided_Resources = 29,
		/// <summary>
		/// Device is using an IRQ resource that another device is using.
		/// </summary>
		Device_Using_IRQ_Resource_In_Use = 30,
		/// <summary>
		/// Device is not working properly; Windows cannot load the required device drivers.
		/// </summary>
		Cannot_Load_Required_Drivers = 31
	}
}