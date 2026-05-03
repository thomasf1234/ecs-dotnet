using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS;

/// <summary>
/// Represents a base class for all systems in the ECS framework.
/// Systems encapsulate game logic that operates on entities with specific component combinations.
/// Override <see cref="Update"/> and/or <see cref="Draw"/> to implement system behavior.
/// </summary>
public abstract class System
{
    /// <summary>
    /// Called once per update cycle to process entities and components.
    /// Override this method to implement system logic.
    /// </summary>
    /// <param name="world">The ECS world providing access to entities and components.</param>
    /// <param name="timeContext">The current time context for the update.</param>
    public virtual void Update(IWorld world, TimeContext timeContext)
    {

    }

    /// <summary>
    /// Called once per draw cycle to render entities or perform draw-related logic.
    /// Override this method to implement rendering or visual effects.
    /// </summary>
    /// <param name="world">The ECS world providing access to entities and components.</param>
    /// <param name="timeContext">The current time context for the draw.</param>
    public virtual void Draw(IWorld world, TimeContext timeContext)
    {

    }
}
