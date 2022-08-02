![example workflow](https://github.com/EugeneKim/EgBlazorComponents/actions/workflows/build.yml/badge.svg)
[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)

# EgBlazorComponents

A collection of Blazor custom components.
I tried to implement them from the scrach and miminise using any 3rd party dependencies unless I have to, because this project is mainly for me to learn the Blazor.
Copyleft licensed. Feel free to download and modify them for your own.
The demo project is included to see how to use them.

### Build Environment
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
