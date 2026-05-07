#include "BaseString.h"

BaseString::BaseString()
{
    value = "";
}

BaseString::BaseString(std::string val)
{
    value = val;
}

BaseString::BaseString(const BaseString& other)
{
    value = other.value;
}

std::string BaseString::getValue() const
{
    return value;
}

int BaseString::getLength() const
{
    return value.length();
}