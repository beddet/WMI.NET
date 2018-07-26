using System;
using WMI.NET.Model.Shared;
using WMI.NET.Model.Shared.Attributes;

namespace WMI.NET.Model.CIM.ManagementSystemElement
{
	/// <summary>
	/// The CIM_ManagedSystemElement class is the base class for the system element hierarchy. Any distinguishable system component is a candidate for inclusion in this class. Examples include software components, such as files; devices, such as disk drives and controllers; and physical components, such as chips and cards.
	/// </summary>
	[WMIClassName("CIM_ManagedSystemElement", true)]
	public class CIM_ManagedSystemElement : IWMIClass
	{
		/// <summary>
		/// Short textual description of the object.
		/// </summary>
		public string Caption { get; set; }
		/// <summary>
		/// Textual description of the object.
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// Indicates the current health of the element. This attribute expresses the health of this element but not necessarily that of its subcomponents. The possible values are 0 to 30, where 5 means the element is entirely healthy and 30 means the element is completely non-functional. The following continuum is defined:
		/// <see cref="HealthStateValue"/>
		/// </summary>
		public ushort HealthState { get; set; }
		/// <summary>
		/// Date and time the object was installed. This property does not need a value to indicate that the object is installed.
		/// </summary>
		public DateTime InstallDate { get; set; }
		/// <summary>
		/// Label by which the object is known. When subclassed, this property can be overridden to be a key property.
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// String that indicates the current status of the object. Operational and non-operational status can be defined. Operational status can include "OK", "Degraded", and "Pred Fail". "Pred Fail" indicates that an element is functioning properly, but is predicting a failure (for example, a SMART-enabled hard disk drive).
		/// Non-operational status can include "Error", "Starting", "Stopping", and "Service". "Service" can apply during disk mirror-resilvering, reloading a user permissions list, or other administrative work. Not all such work is online, but the managed element is neither "OK" nor in one of the other states.
		/// </summary>
		public string Status { get; set; }
		/// <summary>
		/// Indicates the current health of the element. This attribute expresses the health of this element but not necessarily that of its subcomponents. The possible values are 0 to 30, where 5 means the element is entirely healthy and 30 means the element is completely non-functional. The following continuum is defined:
		/// </summary>
		public EHealthState HealthStateValue
		{
			get { return (EHealthState) HealthState; }
		}

		public override string ToString()
		{
			return string.Format("Name: {0}, Caption: {1}, InstallDate: {2}, HealthState: {3}", Name, Caption, InstallDate, HealthStateValue);
		}
	}
}