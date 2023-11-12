> 1. Configuração do Ambiente:  
> Problema: Como você pode verificar se o .NET SDK está corretamente instalado em  seu sistema? Em um arquivo de texto ou Markdown, liste os comandos que podem ser usados para verificar a(s) versão(ões) do .NET SDK instalada(s), como remover e atualizar.  
  
Para verificar se o .NET SDK está corretamente instalado no sistema, pode-se usar os seguintes comandos no terminal ou prompt de comando.

## Obtem informações detalhadas sobre a instalação do .NET SDK no sistema:
```shell
dotnet --info
```
Exibe informações sobre as versões instaladas, runtimes, SDKs e outras configurações.

##  Verifica a versão instalada:
```shell
dotnet --version
```
Este comando exibirá a versão atual do .NET SDK instalada no sistema.

## Lista todas as versões de SDK instaladas:
```shell
dotnet --list-sdks
```

## Verifica a localização da(s) instalação(ões) de .NET SDK no sistema
### Windows:
```powershell
where dotnet
```

### Linux:
```shell
whereis dotnet
```

## Remoção do .NET SDK
### Windows
1. Instala a  Ferramenta de desinstalação do .NET 
```powershell
winget install Microsoft.DotNet.UninstallTool
```

 Exibe quais SDKs podem ser desinstalados com a ferramenta:
```
dotnet-core-uninstall list
```

Exibem os SDKs e os runtimes do .NET que serão removidos com base nas opções fornecidas sem executar a desinstalação:
```powershell
dotnet-core-uninstall dry-run [options] [<VERSION>...]
dotnet-core-uninstall whatif [options] [<VERSION>...]
```

Remove de acordo com opções e versões especificadas:
```powershell
dotnet-core-uninstall remove [options] [<VERSION>...]
```

**Exemplo:** Removendo definitivamente  todos os SDKs e os runtimes do .NET.
```powershell
dotnet-core-uninstall remove --all
```

2. Gerenciadores de pacote
```powershell
 winget uninstall Microsoft.DotNet.SDK.<versão>
```

```powershell
choco uninstall dotnet-sdk
```

```powershell
scoop uninstall dotnet-sdk
``` 

> Caso o .NET SDK tiver sido instalado previamente através do respectivo gerenciador.

### Linux
```bash
sudo apt remove --purge dotnet-sdk-<versão>
```

## Atualização do .NET SDK

1. **Através do [Instalador oficial disponível do .NET](https://dotnet.microsoft.com/download)** ,ou
2. **Através dos scripts de instalação informados em: [dotnet-install scripts - .NET CLI | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-install-script)**:
```shell
# Windows PowerShell
Invoke-WebRequest -Uri https://dot.net/v1/dotnet-install.ps1 -OutFile "$env:temp/dotnet-install.ps1"; powershell -executionpolicy bypass "$env:temp/dotnet-install.ps1" 

# Shell
wget https://dot.net/v1/dotnet-install.sh && chmod +x ./dotnet-install.sh && sudo ./dotnet-install.sh 
```

3. **Através de gerenciadores de pacotes**
### Windows
```powershell
 winget install Microsoft.DotNet.SDK.<versão-principal> -v <versão-especifica>

# Exemplo
winget install Microsoft.DotNet.SDK.7 -v 7.0.100
```

```powershell
choco update dotnet-sdk
```

```powershell
scoop update dotnet-sdk
```

> Caso o .NET SDK tiver sido instalado previamente através do respectivo gerenciador.

### Linux
```shell
sudo apt install dotnet<versão>

# Exemplo
sudo apt install dotnet7
```

