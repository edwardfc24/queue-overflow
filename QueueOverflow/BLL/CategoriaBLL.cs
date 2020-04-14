using QueueOverflow.DAL;
using QueueOverflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueueOverflow.BLL
{
    public class CategoriaBLL
    {
        public static Categoria rowToDto(CategoriaDS.CategoriasRow row)
        {
            Categoria objCategoria = new Categoria();
            objCategoria.idCategoria = row.idCategoria;
            objCategoria.txtNombreCategoria = row.txtNombreCategoria;
            return objCategoria;
        }
        public static List<Categoria> getAllCategories()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            QueueOverflow.DAL.CategoriaDSTableAdapters.CategoriasTableAdapter objDataSet = new QueueOverflow.DAL.CategoriaDSTableAdapters.CategoriasTableAdapter();
            CategoriaDS.CategoriasDataTable dtCategorias = objDataSet.GetAllCategories();

            foreach (CategoriaDS.CategoriasRow row in dtCategorias)
            {
                Categoria objCategoria = rowToDto(row);
                listaCategorias.Add(objCategoria);
            }
            return listaCategorias;
        }
        public static Categoria getCategoryByID(int idCategory)
        {
            Categoria objCategoria = new Categoria();
            QueueOverflow.DAL.CategoriaDSTableAdapters.CategoriasTableAdapter objDataSet = new QueueOverflow.DAL.CategoriaDSTableAdapters.CategoriasTableAdapter();
            CategoriaDS.CategoriasDataTable dtCategorias = objDataSet.GetCategoryByID(idCategory);
            if (dtCategorias.Count > 0)
            {
                objCategoria = rowToDto(dtCategorias[0]);
                return objCategoria;
            }
            return null;
        }
        public static Categoria getCategoryByName(string name)
        {
            Categoria objCategoria = new Categoria();
            QueueOverflow.DAL.CategoriaDSTableAdapters.CategoriasTableAdapter objDataSet = new QueueOverflow.DAL.CategoriaDSTableAdapters.CategoriasTableAdapter();
            CategoriaDS.CategoriasDataTable dtCategorias = objDataSet.GetCategoryByName(name);
            if (dtCategorias.Count > 0)
            {
                objCategoria = rowToDto(dtCategorias[0]);
                return objCategoria;
            }
            return null;
        }
        public static int insertCategory(Categoria category)
        {
            QueueOverflow.DAL.CategoriaDSTableAdapters.CategoriasTableAdapter objDataSet = new QueueOverflow.DAL.CategoriaDSTableAdapters.CategoriasTableAdapter();
            int? id = 0;
            objDataSet.InsertCategory(ref id, category.txtNombreCategoria);
            return (int)id;
        }
        public static void updateCategory(Categoria category)
        {
            QueueOverflow.DAL.CategoriaDSTableAdapters.CategoriasTableAdapter objDataSet = new QueueOverflow.DAL.CategoriaDSTableAdapters.CategoriasTableAdapter();
            objDataSet.UpdateCategory(category.idCategoria, category.txtNombreCategoria);
        }
        public static void deleteCategory(int idCategory)
        {
            QueueOverflow.DAL.CategoriaDSTableAdapters.CategoriasTableAdapter objDataSet = new QueueOverflow.DAL.CategoriaDSTableAdapters.CategoriasTableAdapter();
            objDataSet.DeleteCategory(idCategory);
        }
    }
}