#!/bin/bash

set -e

echo "==> Installazione prerequisiti..."

sudo apt update
sudo apt install -y ca-certificates curl gnupg

echo "==> Creazione keyring..."

sudo install -m 0755 -d /etc/apt/keyrings

curl -fsSL https://download.docker.com/linux/ubuntu/gpg \
| sudo gpg --dearmor --yes -o /etc/apt/keyrings/docker.gpg

sudo chmod a+r /etc/apt/keyrings/docker.gpg

echo "==> Configurazione repository Docker..."

echo "deb [arch=$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.gpg] https://download.docker.com/linux/ubuntu noble stable" \
| sudo tee /etc/apt/sources.list.d/docker.list

echo "==> Aggiornamento repository..."

sudo apt update

echo "==> Installazione Docker..."

sudo apt install -y \
docker-ce \
docker-ce-cli \
containerd.io \
docker-buildx-plugin \
docker-compose-plugin

echo "==> Configurazione utente..."

sudo usermod -aG docker $USER

echo
echo "Docker installato."
echo "Disconnettiti e rientra con PuTTY prima di usarlo."
