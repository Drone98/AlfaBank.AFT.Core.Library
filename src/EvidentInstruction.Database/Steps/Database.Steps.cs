﻿using EvidentInstruction.Database.Controllers;
using EvidentInstruction.Database.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace EvidentInstruction.Database.Steps
{
    /// <summary>
    /// Шаги для работы с БД.
    /// </summary>
    [Binding]
    public class DatabaseSteps
    {
        private readonly DatabaseController databaseController;
        /// <summary>
        /// Initializes a new instance of the <see cref="DB"/> class.
        /// Привязка шагов работы с базами данных к работе с переменным через контекст.
        /// </summary>
        /// <param name="databaseController">Контекст для работы с базой данных.</param>
        /// <param name="variableController">Контекст для работы с переменными.</param>
        public DatabaseSteps(DatabaseController databaseController)
        {
            this.databaseController = databaseController;
        }

        /// <summary>
        /// Очистка подключений к базам данных в конце сценария.
        /// </summary>
        [AfterScenario]
        [Scope(Tag = "SqlServer")]
        [Scope(Tag = "MongoDB")]
        public void AfterScenario()
        {
            foreach (var kvp in this.databaseController.Connections)
            {
                kvp.Value.connection?.Dispose();
            }

            this.databaseController.Connections.Clear();
        }
    }
}
