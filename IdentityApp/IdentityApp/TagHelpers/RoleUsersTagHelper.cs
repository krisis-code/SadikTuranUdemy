using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace IdentityApp.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "asp-role-users")]
    public class RoleUsersTagHelper : TagHelper
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public RoleUsersTagHelper(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HtmlAttributeName("asp-role-users")]
        public string RoleId { get; set; } = null!;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var userNames = new List<string>();
            var role = await _roleManager.FindByIdAsync(RoleId);

            if (role != null && role.Name != null)
            {
                // Kullanıcıları bir liste olarak al
                var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name);

                using (var enumerator = usersInRole.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        var user = enumerator.Current;
                        userNames.Add(user.UserName ?? "");
                    }
                }

                output.Content.SetHtmlContent(userNames.Count == 0 ? "kullanıcı yok" : SetHtml(userNames));
            }
        }


        private string SetHtml(List<string> userNames)
        {
            var html = "<ul>";
            foreach (var item in userNames)
            {
                html += "<li>" + item + "</li>";
            }
            html += "</ul>";
            return html;
        }
    }
}