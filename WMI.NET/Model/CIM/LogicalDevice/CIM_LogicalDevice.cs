using WMI.NET.Model.Shared.Attributes;

namespace WMI.NET.Model.CIM.LogicalDevice
{
	/// <summary>
	/// The CIM_LogicalDevice class represents a hardware entity that may or may not be realized in physical hardware. Logical device characteristics that manage operation or configuration are contained in, or associated with, the CIM_LogicalDevice object. Printer operational properties, for example, are supported paper sizes or detected errors. Sensor device configuration properties, for example, are threshold settings. Various configurations can exist for a logical device and are contained in the CIM_Setting objects, which are associated with the logical device.
	/// </summary>
	[WMIClassName("CIM_LogicalDevice", true)]
	public class CIM_LogicalDevice : CIM_LogicalElement
	{
		/// <summary>
		/// Availability and status of the device.
		/// <see cref="AvailabilityValue"/>
		/// </summary>
		public ushort Availability { get; set; }
		/// <summary>
		/// Win32 Configuration Manager error code.
		/// <see cref="ConfigManagerErrorCodeValue"/>
		/// </summary>
		public uint ConfigManagerErrorCode { get; set; }
		/// <summary>
		/// If TRUE, the device is using a user-defined configuration. This property is inherited from CIM_LogicalDevice.
		/// </summary>
		public bool ConfigManagerUserConfig { get; set; }
		/// <summary>
		/// Name of the class or subclass used in the creation of an instance. When used with other key properties of the class, this property allows all instances of the class and its subclasses to be uniquely identified. This property is inherited from CIM_LogicalDevice.
		/// </summary>
		public string CreationClassName { get; set; }
		/// <summary>
		/// Address or other identifying information to uniquely name the logical device. This property is inherited from CIM_LogicalDevice.
		/// </summary>
		public string DeviceID { get; set; }
		/// <summary>
		/// If TRUE, the error reported in the LastErrorCode property is now cleared. This property is inherited from CIM_LogicalDevice.
		/// </summary>
		public bool ErrorCleared { get; set; }
		/// <summary>
		/// Free-form string that supplies information about the error recorded in the LastErrorCode property and corrective actions to perform. This property is inherited from CIM_LogicalDevice.
		/// </summary>
		public string ErrorDescription { get; set; }
		/// <summary>
		/// Last error code reported by the logical device.
		/// </summary>
		public uint LastErrorCode { get; set; }
		/// <summary>
		/// Indicates the Win32 Plug and Play device identifier of the logical device.
		/// Example: "*PNP030b"
		/// </summary>
		public string PNPDeviceID { get; set; }
		/// <summary>
		/// Array of the specific power-related capabilities of a logical device. This property is inherited from CIM_LogicalDevice.
		/// <see cref="PowerManagementCapabilitiesValue"/>
		/// </summary>
		public ushort[] PowerManagementCapabilities { get; set; }
		/// <summary>
		/// If TRUE, the device can be power managed, that is, put into a power-save state. If FALSE, the integer value 1 ("Not Supported") should be the only entry in the PowerManagementCapabilities array.
		/// This property does not indicate whether power management features are currently enabled, or if enabled, which features are supported. For more information, see the PowerManagementCapabilities array.
		/// </summary>
		public bool PowerManagementSupported { get; set; }
		/// <summary>
		/// State of the logical device. If this property does not apply to the logical device, the value 5 ("Not Applicable") should be used. This property is inherited from CIM_LogicalDevice.
		/// <see cref="StatusInfoValue"/>
		/// </summary>
		public ushort StatusInfo { get; set; }
		/// <summary>
		/// State of the logical device. If this property does not apply to the logical device, the value 5 ("Not Applicable") should be used. This property is inherited from CIM_LogicalDevice.
		/// </summary>
		public string SystemCreationClassName { get; set; }
		/// <summary>
		/// Scoping system's name.
		/// </summary>
		public string SystemName { get; set; }
		/// <summary>
		/// Availability and status of the device.
		/// </summary>
		public EAvailability AvailabilityValue
		{
			get { return (EAvailability) Availability; }
		}

		private EPowerManagementCapabilities[] _ePowerManagementCapabilitieses;
		/// <summary>
		/// Array of the specific power-related capabilities of a logical device. This property is inherited from CIM_LogicalDevice.
		/// </summary>
		public EPowerManagementCapabilities[] PowerManagementCapabilitiesValue
		{
			get
			{
				int length = PowerManagementCapabilities.Length;
				if (_ePowerManagementCapabilitieses == null || _ePowerManagementCapabilitieses.Length != length)
				{
					_ePowerManagementCapabilitieses = new EPowerManagementCapabilities[length];
					for (int i = 0; i < length; i++)
					{
						_ePowerManagementCapabilitieses[i] = (EPowerManagementCapabilities)PowerManagementCapabilities[i];
					}
				}

				return _ePowerManagementCapabilitieses;
			}
		}

		public override string ToString()
		{
			return string.Format("DeviceID: {0}, SystemName: {1}, Availability: {2}", DeviceID, SystemName, AvailabilityValue);
		}

		/// <summary>
		/// Win32 Configuration Manager error code.
		/// </summary>
		public EConfigManagerErrorCode ConfigManagerErrorCodeValue
		{
			get { return (EConfigManagerErrorCode)ConfigManagerErrorCode; }
		}

		/// <summary>
		/// State of the logical device. If this property does not apply to the logical device, the value 5 ("Not Applicable") should be used. This property is inherited from CIM_LogicalDevice.
		/// </summary>
		public EStatusInfo StatusInfoValue
		{
			get { return (EStatusInfo)StatusInfo; }
		}
	}
}