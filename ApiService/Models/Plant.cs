using System.ComponentModel.DataAnnotations;

namespace ApiService.Models;

public class Plant : CatalogItem
{
    [MaxLength(255)] public string Species { get; set; } = string.Empty;
    [MaxLength(500)] public string Description { get; set; } = string.Empty;

    public bool StartIndoors { get; set; }

/*
 The following properties save how many weeks from the last frost the item should be planted.
 Negative numbers are before last frost and Positive are after last frost
 */
    public int? StartIndoorsWeeksLower { get; set; }
    public int? StartIndoorsWeeksUpper { get; set; }
    public int? StartOutdoorsWeeksLower { get; set; }
    public int? StartOutdoorsWeeksUpper { get; set; }
    [MaxLength(1000)] public string? PlantingInstructions { get; set; } = string.Empty;

    public int? HardinessZoneLower { get; set; }
    public int? HardinessZoneUpper { get; set; }

    public int? DaysToGerminate { get; set; }
    public int? DaysToMaturity { get; set; }
    public float? RowSpacing { get; set; } // in inches
    public float? PlantSpacing { get; set; } // in inches
    public int? MinSunLower { get; set; }
    public int? MinSunUpper { get; set; }
    public int? MinWaterLower { get; set; } // in inches
    public int? MinWaterUpper { get; set; } // in inches
}