using System;
using Domain.Enums;

namespace Domain.Models.Orders
{
    public class User : BaseWfmObject
    {
        public int Reputation { get; set; }
        public int ReputationBonus { get; set; }
        public string Region { get; set; }
        public DateTime LastSeen { get; set; }
        public string AvatarUrl { get; set; }
        public string WarframeUserName { get; set; }
        public UserStatusType Status { get; set; }
    }
}
