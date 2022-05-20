#!/bin/bash
set -e

echo "Installing .NET tools"
if ! dotnet ef -v &> /dev/null
then
    dotnet tool install --global dotnet-ef
fi

echo "Preparing frontend"
cd pweb_frontend
npm install
cd ..

echo "Preparing backend"
cd bePetAway
dotnet restore
cd ..

echo "Preparing mail service"
cd mailService
npm install
cd ..


echo "Preparing dependencies"
npm run deps