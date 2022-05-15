#!/bin/bash
set -e

npm run docker:api:build
npm run docker:frontend:build
npm run docker:mail:build