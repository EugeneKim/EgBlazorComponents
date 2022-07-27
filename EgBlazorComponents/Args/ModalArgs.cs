namespace EgBlazorComponents.Args
{
	public enum ModalButtons
	{
		Ok,
		Cancel,
		OkCancel,
		Yes,
		YesNo,
		None
	}

	public enum ModalResult
	{
		Ok,
		Yes,
		No,
		Cancel
	}

	public class ModalArgs<T> where T : class
	{
		public ModalButtons ModalButtons { get; }
		public T Data { get; }

		public ModalArgs(T data) : this(ModalButtons.None, data) { }

		public ModalArgs(ModalButtons modalButtons, T data)
		{
			ModalButtons = modalButtons;
			Data = data;
		}
	}
}
