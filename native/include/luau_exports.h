#pragma once

#include <stddef.h>

#ifndef LUAU_EXPORT_API
#ifdef _MSC_VER
#define LUAU_EXPORT_API extern __declspec(dllexport)
#else
#define LUAU_EXPORT_API extern __attribute__((visibility("default")))
#endif
#endif

#ifdef __cplusplus
extern "C"
{
#endif

LUAU_EXPORT_API void luau_free(void* ptr);

#ifdef __cplusplus
}
#endif
