using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Browser.Model
{
	public class NotificationObject : INotifyPropertyChanged
	{
		public void OnPropertyChanged<TProperty>(Expression<Func<TProperty>> property)
		{
			var lambda = (LambdaExpression)property;
			MemberExpression memberExpression;
			if (lambda.Body is UnaryExpression)
			{
				var unaryExpression = (UnaryExpression)lambda.Body;
				memberExpression = (MemberExpression)unaryExpression.Operand;
			}
			else memberExpression = (MemberExpression)lambda.Body;
			OnPropertyChanged(memberExpression.Member.Name);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}