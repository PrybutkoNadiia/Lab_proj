#ifndef BASESTRING_H
#define BASESTRING_H

#include <string>

class BaseString
{
protected:
    std::string value;

public:
    BaseString();
    BaseString(std::string val);
    BaseString(const BaseString& other);

    std::string getValue() const;
    int getLength() const;
};

#endif