using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using LibrarySystemForDemo.Authorization;

namespace LibrarySystemForDemo.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class LibrarySystemForDemoNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu



                //.AddItem(
                //    new MenuItemDefinition(
                //        PageNames.About,
                //        L("About"),
                //        url: "About",
                //        icon: "fas fa-info-circle"
                //    )
                //)

                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    )
                )

                /*   Departments   */
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Departments,
                        L("Departments"),
                        url: "Department",
                        icon: "fas fa-sitemap",
                        requiresAuthentication: true
                    )
                )
                /*   Departments   */

                /*   Students   */
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Students,
                        L("Students"),
                        url: "Student",
                        icon: "fas fa-graduation-cap",
                        requiresAuthentication: true
                    )
                )
                /*   Students   */

                /*   Book Category   */
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.BookCategories,
                        L("BookCategories"),
                        url: "Category",
                        icon: "fas fa-list-alt",
                        requiresAuthentication: true
                    )
                )
                /*   Book Category   */

                /*      Authors        */
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Authors,
                        L("Author"),
                        url: "Author",
                        icon: "fas fa-pencil-alt",
                        requiresAuthentication: true
                    )
                )
                /*      Authors       */

                /*      Books        */
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Books,
                        L("Books"),
                        url: "Book",
                        icon: "fas fa-book-medical",
                        requiresAuthentication: true
                    )
                )
                /*      Books       */

                /*      Borrower        */
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Borrowers,
                        L("Borrower"),
                        url: "Borrower",
                        icon: "fas fa-hand-holding",
                        requiresAuthentication: true
                    )
                );
                /*      Borrower       */

                /*  ; */    

                //.AddItem(
                //    new MenuItemDefinition(
                //        PageNames.Tenants,
                //        L("Tenants"),
                //        url: "Tenants",
                //        icon: "fas fa-building",
                //        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
                //    )
                //)
                
                //.AddItem(
                //    new MenuItemDefinition(
                //        PageNames.Users,
                //        L("Users"),
                //        url: "Users",
                //        icon: "fas fa-users",
                //        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                //    )
                //)

                //.AddItem(
                //    new MenuItemDefinition(
                //        PageNames.Roles,
                //        L("Roles"),
                //        url: "Roles",
                //        icon: "fas fa-theater-masks",
                //        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                //    )
                //);
                
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LibrarySystemForDemoConsts.LocalizationSourceName);
        }
    }
}