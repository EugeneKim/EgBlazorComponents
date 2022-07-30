[![Build Status](https://travis-ci.com/EugeneKim/EgBlazorComponents.svg?branch=main)](https://travis-ci.com/EugeneKim/EgBlazorComponents)
[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)

# EgBlazorComponents

A collection of Blazor custom components.
This package is intended for educational purposes for my colleagues who are new to Blazor world.
Therefore, I tried to NOT reuse or wrap any 3rd party dependencies.
And I also tried to make the implementation simple as possible as I can.
Feel free to download and modify the package source from GitHub for the projects for you or your team.
The demo project included in the package source demonstrates how to use the components.

### Build Environment
https://docs.microsoft.com/en-us/aspnet/core/blazor/forms-validation
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)

#### Modal
- Modal dialog\
Please note that *I referred a lot to the parts [Blazored Modal](https://github.com/Blazored/Modal) is implemented for this component.*

#### InputSetEnum
- Extended the built-in InputSet to support *enum* type.

#### Pagination
- Normal pagination component.

#### Spinner
- Loading indicator with spinning animation.

#### Table
This component focuses on:
- Auto detection the properties of the data context bound to.
- Partial data load only for current page to avoid performance hit by large data.

### Note
There are nice/cool open-source Blazor components in GitHub. You may want to crack them open for your advanced level of Blazor.

- [Awesome Blazor](https://github.com/AdrienTorris/awesome-blazor)
- [Blazorise](https://github.com/stsrki/Blazorise)
- [Blazored](https://github.com/Blazored)
- [Grid.Blazor](https://github.com/gustavnavar/Grid.Blazor)