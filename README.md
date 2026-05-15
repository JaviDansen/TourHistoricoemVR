# Trapiche Conectado VR

Sistema de Tour Histórico em Realidade Virtual desenvolvido na Unity, com foco em educação patrimonial, narrativa guiada e interação imersiva sobre o patrimônio histórico do Trapiche Maranhense.

---

# 📚 Sobre o Projeto

O Trapiche Conectado VR é uma experiência educacional em Realidade Virtual que permite ao usuário explorar ambientes históricos do Trapiche Maranhense por meio de estações interativas, narração contextual e progressão guiada.

O projeto busca unir:

- Educação patrimonial
- Imersão em VR
- Narrativa interativa
- Preservação histórica
- Gamificação educativa

---

# 🎯 Objetivos

- Apresentar a história do Trapiche Maranhense de forma imersiva
- Facilitar o aprendizado através de interação em VR
- Criar uma experiência narrativa guiada por estações
- Integrar áudio, UI e progressão contextual
- Aplicar conceitos de desenvolvimento XR na Unity

---

# 🥽 Funcionalidades

## ✅ Sistema de Tour Guiado

- Progressão entre estações
- Teleporte automático
- Objetivos dinâmicos na HUD
- Controle narrativo por etapas

---

## ✅ Sistema de UI em VR

- Interfaces World Space
- Painéis contextuais
- Botões interativos
- Sistema modular por estação

---

## ✅ Sistema de Narração

- Reprodução de áudio por estação
- Controle Play/Pause
- Áudio contextual histórico

---

## ✅ Sistema de Fade VR

- Transição visual suave
- Redução de desconforto em teleporte
- Melhor experiência imersiva

---

## ✅ Estrutura Modular

Cada estação possui:

- UI própria
- Áudio próprio
- Controle de progressão próprio
- Objetivos independentes

---

# 🏛️ Estações do Tour

## 🔸 Chaminés
Apresentação inicial sobre o patrimônio industrial do Trapiche.

## 🔸 Destroços Industriais
Exploração dos vestígios industriais e marcas históricas do espaço.

## 🔸 Armazém Dona Teté
Contextualização histórica e cultural do armazém.

## 🔸 Armazém Humberto Maracanã
Encerramento da exploração histórica principal.

## 🔸 Pátio Final
Área destinada ao Quiz Educativo e encerramento do tour.

---

# 🧠 Tecnologias Utilizadas

## Engine
- Unity 6

## Linguagem
- C#

## XR
- XR Interaction Toolkit
- OpenXR

## UI
- TextMeshPro

---

# 🗂️ Estrutura do Projeto

```text
Assets/
├── Scripts/
│   ├── BoasVindasController.cs
│   ├── StationProgress.cs
│   ├── FadeController.cs
│   ├── PlayNarration.cs
│   └── TourObjectiveManager.cs
│
├── Audio/
├── Models/
├── UI/
└── Scenes/
```

---

# 🔄 Fluxo do Sistema

```text
BoasVindas
    ↓
Fade In
    ↓
Teleporte
    ↓
UI da estação
    ↓
Narração
    ↓
Usuário interage
    ↓
Próxima estação
```

---

# 🧩 Arquitetura das Estações

Cada estação segue o padrão:

```text
UI_Estacao
├── Canvas
├── AudioSource
├── PlayNarration
└── StationProgress
```

---

# 🎮 Controles

## Desktop
- Mouse
- Teclado

## VR
- XR Controllers
- Interação via Raycast

---

# 🚧 Funcionalidades Futuras

- Quiz educativo final
- Sistema de pontuação
- Salvamento de progresso
- Melhorias visuais
- Otimização VR
- Efeitos sonoros ambientais
- Sistema de analytics educacional

---

# 👨‍💻 Equipe

Projeto acadêmico desenvolvido para fins educacionais e de pesquisa em Realidade Virtual aplicada ao patrimônio histórico.

---

# 📄 Licença

Projeto desenvolvido para fins acadêmicos.