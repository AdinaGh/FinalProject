using DataAccess;
using DataAccess.Interfaces;
using Entities.Models;
using Services;
using Services.Interfaces;
using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Web.Controllers;
using Web.Models;

namespace Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IRecipeRepository, RecipeRepository>();
            container.RegisterType<IRecipeService, RecipeService>();
            container.RegisterType<ICuisineRepository, CuisineRepository>();
            container.RegisterType<ICuisineService, CuisineService>();
            container.RegisterType<IDificultyRepository, DificultyRepository>();
            container.RegisterType<IDificultyService, DificultyService>();
            container.RegisterType<IRecipeOccasionService, RecipeOccasionService>();
            container.RegisterType<IRecipeIngredientService, RecipeIngredientService>();
            container.RegisterType<IRecipeCategoryService, RecipeCategoryService>();

            container.RegisterType<IUserRatingService, UserRatingService>();
            container.RegisterType<IRecipeStepService, RecipeStepService>();
            container.RegisterType<ICommentService, CommentService>();

            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());


            container.RegisterType(typeof(IRepository<>), typeof(Repository<>), new TransientLifetimeManager());
            container.RegisterType(typeof(IService<>), typeof(Service<>), new TransientLifetimeManager());

        }
    }
}