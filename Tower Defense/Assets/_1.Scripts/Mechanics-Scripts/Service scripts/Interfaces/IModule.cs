using ConfigClasses.BuildingConfig;

public interface IModule
{
    IModuleHub FindParentHub();
    void SetSpecifications(BuildingsConfig specifications);
}
