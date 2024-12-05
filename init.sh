#!/bin/bash

# Aplica as migrações no banco de dados
echo "Aplicando migrações no banco de dados..."
dotnet ef database update --context BurguerManiaDbContext --server db

# Inicia a aplicação
echo "Iniciando a aplicação..."
dotnet burguermania-backend.dll
