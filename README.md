# SimpleFeatureToggler
Simple feature toggler for .NET.

# Usage

Currently only two toggles exist, boolean and date toggles.

To use a boolean toggle:

Inherit from the class SimpleToggle and add the toggle to the appsettings.

```
<add key="SimpleToggleTrueDummy.IsEnabled" value="true"/>
```

To use a date toggle:

Inherit from the class DateToggle and add the toggle to the appsettings. DateToggles have two values, StartDate and EndDate. Only one is required for the toggle to work.

```
<add key="TrueStartAndEndDateTimeDummy.StartDate" value="1900-01-01"/>
<add key="TrueStartAndEndDateTimeDummy.EndDate" value="2900-01-01"/>
```

To check if the toggle is enabled just call the IsEnabled method on the class.
