using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS;

/// <summary>
/// Represents timing information for a single update or draw cycle in the ECS framework.
/// Provides the elapsed time since the last frame and the total elapsed time since the start.
/// </summary>
public class TimeContext
{
    /// <summary>
    /// Gets or sets the elapsed time in seconds since the last update or draw call.
    /// </summary>
    public double DeltaTime { get; set; }

    /// <summary>
    /// Gets or sets the total elapsed time in seconds since the start of the game.
    /// </summary>
    public double TotalTime { get; set; }
}