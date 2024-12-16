using Entities.Models;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;


namespace Blazor.Pages.Category
{
	public partial class CategoryView
	{
		private List<CategoryModel>? categories;
		RadzenDataGrid<CategoryModel>? categoriesGrid;
		List<CategoryModel> categoriesToInsert = new List<CategoryModel>();
		private CategoryModel newCategory = new CategoryModel(); // Added

		protected override async Task OnInitializedAsync()
		{

			await _authMethods.CheckAuthBeforeRequests();
			categories = await _categoryService.GetCategoriesAsync();
		}

		async Task InsertRow()
		{
			newCategory = new CategoryModel(); 
			categoriesToInsert.Add(newCategory);
			await categoriesGrid.InsertRow(newCategory); 
		}

		async Task OnCreateRow(CategoryModel category)
		{
			await _categoryService.AddCategoryAsync(category);
			await Task.Delay(TimeSpan.FromSeconds(0.1));
			categories = await _categoryService.GetCategoriesAsync();
			await InvokeAsync(StateHasChanged);
		}

		void CancelEdit(CategoryModel categoryModel)
		{
			categoriesGrid.CancelEditRow(categoryModel);

		}

		void SaveRow(CategoryModel categoryModel)
		{
			categoriesGrid?.UpdateRow(categoryModel);

		}
		async Task OnUpdateRow(CategoryModel categoryModel)
		{

			await _categoryService.UpdateCategoryAsync(categoryModel);
			await Task.Delay(TimeSpan.FromSeconds(0.2));
			categories = await _categoryService.GetCategoriesAsync();
			await InvokeAsync(StateHasChanged);
		}

		async void DeleteRow(CategoryModel model)
		{
			await _categoryService.DeleteCategoryAsync(model.Id);
			categories = await _categoryService.GetCategoriesAsync();
			await InvokeAsync(StateHasChanged);
		}

		void EditRow(CategoryModel model) { categoriesGrid.EditRow(model); }
	}
}
