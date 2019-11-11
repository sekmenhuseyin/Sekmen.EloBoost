using EloBoost.Sessions.Dto;

namespace EloBoost.Web.Views.Shared.Components.SideBarUserArea
{
    public class SideBarUserAreaViewModel
    {
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }

        public string GetShownLoginName()
        {
            return "<span id=\"HeaderCurrentUserName\">" + LoginInformations.User.UserName + "</span>";
        }
    }
}
