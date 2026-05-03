namespace ECS;

/// <summary>
/// Defines the contract for a type-erased, fixed-size, densely packed array of components
/// supporting fast insertion, removal, and lookup by entity ID.
/// Used internally by the ECS to manage component storage in a generic way.
/// </summary>
internal interface IComponentArray
{
    /// <summary>
    /// Removes the component associated with the specified entity ID.
    /// </summary>
    /// <param name="id">The entity ID of the component to remove.</param>
    void RemoveAt(int id);

    /// <summary>
    /// Retrieves the component associated with the specified entity ID as an object.
    /// </summary>
    /// <param name="id">The entity ID of the component.</param>
    /// <returns>The component as an object.</returns>
    object GetBoxed(int id);

    /// <summary>
    /// Inserts a component (boxed) with the specified entity ID.
    /// </summary>
    /// <param name="id">The entity ID to associate with the component.</param>
    /// <param name="value">The component to insert (as object).</param>
    void Insert(int id, object value);

    /// <summary>
    /// Updates the component (boxed) associated with the specified entity ID.
    /// </summary>
    /// <param name="id">The entity ID of the component to update.</param>
    /// <param name="value">The new component value (as object).</param>
    void Update(int id, object value);
}