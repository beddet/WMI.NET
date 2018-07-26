namespace WMI.NET.Model.CIM.ManagementSystemElement
{
	public enum EHealthState : ushort
	{
		/// <summary>
		/// The implementation cannot report on HealthState at this time.
		/// </summary>
		Unknown = 0,
		/// <summary>
		/// The element is fully functional and is operating within normal operational parameters and without error.
		/// </summary>
		OK = 5,
		/// <summary>
		/// The element is in working order and all functionality is provided. However, the element is not working to the best of its abilities. For example, the element might not be operating at optimal performance or it might be reporting recoverable errors.
		/// </summary>
		Degraded_Warning = 10,
		/// <summary>
		/// All functionality is available but some might be degraded.
		/// </summary>
		Minor_Failure = 15,
		/// <summary>
		/// The element is failing. It is possible that some or all of the functionality of this component is degraded or not working.
		/// </summary>
		Major_Failure = 20,
		/// <summary>
		/// The element is non-functional and recovery might not be possible.
		/// </summary>
		Critical_Failure = 25,
		/// <summary>
		/// The element has completely failed, and recovery is not possible. All functionality provided by this element has been lost.
		/// </summary>
		Non_recoverable_error = 30
	}
}