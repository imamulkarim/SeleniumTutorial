using SeleniumXUnitPractice.grid.third.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumXUnitPractice.grid.third
{
	public static class ToDoFacade
	{
		//private readonly MainPage _mainPage;
		//private readonly TodoPageApp _todoPageApp;

		//public ToDoFacade(MainPage mainPage, TodoPageApp todoPageApp)
		//{
		//	_mainPage = mainPage;
		//	_todoPageApp = todoPageApp;
		//}

		public static void VerifyTodoListCreateSuccessfully(string technology, List<string> itemsToAdd, List<string> itemsToCheck, int expectedItemsToLeft)
		{
			MainPage.Open();
			MainPage.OpenTechnologyApp(technology);
			itemsToAdd.ForEach(item => TodoPageApp.AddNewToDoItem(item));
			itemsToCheck.ForEach(item => TodoPageApp.GetItemCheckBox(item).Click());
			TodoPageApp.AssertLeftItems(expectedItemsToLeft);
		}


	}
}
