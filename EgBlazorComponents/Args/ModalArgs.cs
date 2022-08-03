namespace EgBlazorComponents.Args
{
	/// <summary>
	/// Modal button types
	/// </summary>
	public enum ModalButtons
	{
		Ok,
		Cancel,
		OkCancel,
		Yes,
		YesNo,
		None
	}

	/// <summary>
	/// Modal result returned to the caller.
	/// </summary>
	public enum ModalResult
	{
		Ok,
		Yes,
		No,
		Cancel
	}

	/// <summary>
	/// Instance of the arguments passed/returned to the modal.
	/// </summary>
	/// <typeparam name="T">Data type</typeparam>
	public class ModalArgs<T> where T : class
	{
		#region Properties

		/// <summary>
		/// Modal button types.
		/// </summary>
		public ModalButtons ModalButtons { get; }

		/// <summary>
		/// Data passed into the modal.
		/// </summary>
		public T Data { get; }

		#endregion Properties

		#region Construction

		public ModalArgs(T data) : this(ModalButtons.None, data) { }

		public ModalArgs(ModalButtons modalButtons, T data)
		{
			ModalButtons = modalButtons;
			Data = data;
		}

		#endregion Construction
	}
}
