using SeleniumXUnitPractice.third.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumXUnitPractice.third
{
	public class PagesFixture : IDisposable
	{

		public PagesFixture()
		{
			MainPage = new MainPage(DriverFixture.Driver.Value);
			TodoPageApp = new TodoPageApp(DriverFixture.Driver.Value);
			ToDoFacade = new ToDoFacade(MainPage, TodoPageApp);
		}

		public MainPage MainPage { get; set; }
		public TodoPageApp TodoPageApp { get; set; }
		public ToDoFacade ToDoFacade { get; set; }

		public void Dispose()
		{

		}
	}
}
