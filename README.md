# \# SyncSentinel

# 

# SyncSentinel is a realistic mid-level .NET backend project for operations and support-heavy environments.

# 

# It is designed as a containerized incident and integration platform that helps teams track incidents, manage sync jobs, monitor operational events, and process background workflows in a practical, production-style way.

# 

# This project is intentionally built to reflect real-world backend responsibilities such as:

# 

# \- API development

# \- SQL Server persistence

# \- support/debugging workflows

# \- retry handling

# \- integration event tracking

# \- background job processing

# \- operational visibility

# \- root cause analysis support

# 

# The goal is to build something more believable than a toy CRUD app and more practical than an overengineered architecture demo.

# 

# \---

# 

# \## Why this project exists

# 

# Many backend developers work on systems where the real complexity is not in flashy UI, but in:

# 

# \- failed integrations

# \- partial syncs

# \- incident tracking

# \- retry logic

# \- operational support

# \- event-driven processing

# \- logging and debugging across systems

# 

# SyncSentinel is built around that kind of work.

# 

# It is meant to feel relevant for developers with experience in:

# 

# \- C# / .NET

# \- ASP.NET Core Web API

# \- SQL Server

# \- background services

# \- debugging and RCA

# \- API and data integrations

# \- operational support systems

# 

# \---

# 

# \## V1 Scope

# 

# Version 1 focuses on the foundation of the platform.

# 

# \### Core features

# \- Create incident

# \- Get all incidents

# \- Get incident by ID

# \- Create sync job

# \- List sync jobs

# \- Retry sync job

# \- SQL persistence

# \- RabbitMQ event publishing and consuming

# \- Background worker processing

# \- Dockerized local setup

# 

# \### Planned later

# \- AI-assisted incident summary generation

# \- probable RCA suggestions using a local model

# \- richer retry workflows

# \- event search and filtering

# \- operational dashboards

# \- notification workflows

# 

# \---

# 

# \## Solution structure

# 

# ```text

# SyncSentinel

# |

# +-- SyncSentinel.API

# |   ASP.NET Core Web API

# |   Controllers, Swagger, API configuration

# |

# +-- SyncSentinel.Application

# |   DTOs, service contracts, application logic

# |

# +-- SyncSentinel.Domain

# |   Core entities and enums

# |

# +-- SyncSentinel.Infrastructure

# |   EF Core, DbContext, persistence, DI registration

# |

# +-- SyncSentinel.Worker

# |   Background processing and RabbitMQ consumers

# |

# +-- SyncSentinel.Tests

# |   xUnit tests

