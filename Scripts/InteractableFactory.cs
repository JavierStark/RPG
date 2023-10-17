class InteractableFactory<T> : IFactory where T : IInteractable, new()
{
  IInteractable IFactory.Create()
  {
    return new T();
  }
}


