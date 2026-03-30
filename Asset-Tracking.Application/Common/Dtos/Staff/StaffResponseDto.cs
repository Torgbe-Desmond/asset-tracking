namespace Asset_Tracking.Application.Common.Dtos.Staff
{
    /// <summary>
    /// Represents the personal and location details of a staff member.
    /// </summary>
    public record StaffResponseDto
    {
        /// <example>STF-9982</example>
        public string StaffId { get; set; } = default!;

        /// <example>1</example>
        public int? TitleId { get; set; }

        /// <example>Doe</example>
        public string Surname { get; set; } = default!;

        /// <example>John Kwabena</example>
        public string OtherName { get; set; } = default!;

        /// <example>j.doe@tech-firm.com</example>
        public string TechMail { get; set; } = default!;

        /// <example>2</example>
        public int? SiteId { get; set; }

        /// <example>1</example>
        public int? BuildingId { get; set; }

        /// <example>3</example>
        public int? FloorId { get; set; }

        /// <example>12</example>
        public int? RoomId { get; set; }

        /// <example>true</example>
        public bool? HasRoom { get; set; }

        /// <example>Located near the IT helpdesk, East Wing.</example>
        public string? RoomLocationDescription { get; set; }
    }
}