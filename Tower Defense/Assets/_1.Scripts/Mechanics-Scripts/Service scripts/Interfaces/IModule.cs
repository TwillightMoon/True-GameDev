using ConfigClasses.TowerConfig;

public interface IModule
{
    IModuleHub FindParentHub();
    void SetSpecifications(TowerConfig specifications);
}
