using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System.Collections.Generic;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class CategoryTests : IDisposable
  {
    public void Dispose()
    {
      Category.ClearAll();
    }

    [TestMethod]
    public void CategoryConstructor_CreatesInstanceOfCategory_Category()
    {
      Category newCategory = new Category("test category");
      Assert.AreEqual(typeof(Category), newCategory.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string name = "Test Category";
      Category newCategory = new Category(name);
      string result = newCategory.Name;
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetId_ReturnsCategoryId_Int()
    {
      string name = "Test Category";
      Category newCategory = new Category(name);
      int result = newCategory.Id;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllCategoryObjects_CategoryList()
    {
      //Arrange
      string name01 = "Work";
      string name02 = "School";
      Category newCategory1 = new Category(name01);
      Category newCategory2 = new Category(name02);
      List<Category> newList = new List<Category> { newCategory1, newCategory2 };

      //Act
      List<Category> result = Category.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

      [TestMethod]
    public void Find_ReturnsCorrectCategory_Category()
    {
      //Arrange
      string name01 = "Work";
      string name02 = "School";
      Category newCategory1 = new Category(name01);
      Category newCategory2 = new Category(name02);

      //Act
      Category result = Category.Find(2);

      //Assert
      Assert.AreEqual(newCategory2, result);
    }

    [TestMethod]
    public void AddItem_AssociatesItemWithCategory_ItemList()
    {
      string description = "Walk the dog.";
      Item newItem = new Item(description);
      List<Item> newList = new List<Item> { newItem };
      string name = "work";
      Category newCategory = new Category(name);
      newCategory.AddItem(newItem);
      List<Item> result = newCategory.Items;
      CollectionAssert.AreEqual(newList, result);
    }
  }
}