using System;
using Domain.Enums;

namespace Domain.Models.Orders
{
    public class User : BaseWfmObject
    {
        public int Reputation { get; set; }          //reputation
        public int ReputationBonus { get; set; }     //reputation_bonus
        public string Region { get; set; }           //region
        public DateTime LastSeen { get; set; }       //last_seen
        public string AvatarUrl { get; set; }        //avatar
        public string WarframeUserName { get; set; } //ingame_name
        public UserStatusType Status { get; set; }   //status
    }
}
