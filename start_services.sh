#!/usr/bin/env sh

sh -e "sh -c 'cd Frontend/todo && npm install && npm start'"
sh -e "sh -c 'cd Backend/Todo.Api && dotnet run --project Todo.Api'"