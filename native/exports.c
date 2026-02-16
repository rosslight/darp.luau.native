#include "include/luau_exports.h"

#include <stdlib.h>

void luau_free(void* ptr)
{
    free(ptr);
}
