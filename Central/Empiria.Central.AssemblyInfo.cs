﻿/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  System   : Empiria Central Framework                    Module  : Domain Layer                            *
*  Assembly : Empiria.Central.dll                          Pattern : Assembly Attributes File                *
*                                                          License : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Contains centralized general purpose domain classes, types an services; useful to              *
*             build domain specific applications.                                                            *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

/*************************************************************************************************************
* Assembly configuration attributes.                                                                         *
*************************************************************************************************************/
[assembly: AssemblyTrademark("Empiria and Ontica are either trademarks of La Vía Óntica SC or Ontica LLC.")]
[assembly: AssemblyCulture("")]
[assembly: CLSCompliant(true)]
[assembly: InternalsVisibleTo("Empiria.Central.Tests")]
[assembly: InternalsVisibleTo("Empiria.Central.Services")]
[assembly: InternalsVisibleTo("Empiria.Central.Services.Tests")]
