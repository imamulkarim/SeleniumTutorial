using SeleniumXUnitPractice.third.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumXUnitPractice.third
{
	public class ToDoFacade
	{

		private readonly MainPage _mainPage;
		private readonly TodoPageApp _todoPageApp;

		public ToDoFacade(MainPage mainPage, TodoPageApp todoPageApp)
		{
			_mainPage = mainPage;
			_todoPageApp = todoPageApp;
		}

		public void VerifyTodoListCreateSuccessfully(string technology, List<string> itemsToAdd, List<string> itemsToCheck, int expectedItemsToLeft)
		{
			_mainPage.Open();
			_mainPage.OpenTechnologyApp(technology);
			itemsToAdd.ForEach(item => _todoPageApp.AddNewToDoItem(item));
			itemsToCheck.ForEach(item => _todoPageApp.GetItemCheckBox(item).Click());
			_todoPageApp.AssertLeftItems(expectedItemsToLeft);
		}

	}
}
