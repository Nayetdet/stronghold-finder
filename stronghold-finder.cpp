#include <iostream>
#include <cmath>
#include <regex>
#include <sstream>
#include <vector>
#include <algorithm>
#include <windows.h>

using namespace std;

class Coordinates {
public:
    vector<double> x, y, z, h, v;
    Coordinates() {
        clearUserClipboard();
        processUserRawCoordinates(fetchUserInput());
        cout << '\n';
    }

private:
    static constexpr const char* REGEX_PATTERN = R"(^\/execute in minecraft:overworld run tp @s ((?:-?\d+\.\d{2}\s){4}-?\d+\.\d{2})$)";
    static constexpr int MAX_ALLOWED_ENDER_EYE_THROWS = 2;
    static constexpr int SLEEP_TIME = 250;

    void clearUserClipboard() {
        if (OpenClipboard(nullptr)) {
            EmptyClipboard();
            const char* textToCopy = "";
            HGLOBAL hGlobalMem = GlobalAlloc(GMEM_MOVEABLE, strlen(textToCopy) + 1);
            if (hGlobalMem != nullptr) {
                char* pGlobalMem = static_cast<char*>(GlobalLock(hGlobalMem));
                if (pGlobalMem != nullptr) {
                    strcpy(pGlobalMem, textToCopy);
                    SetClipboardData(CF_TEXT, hGlobalMem);
                    GlobalUnlock(hGlobalMem);
                }
                GlobalFree(hGlobalMem);
            }
            CloseClipboard();
        }
    }

    vector<string> fetchUserInput() {
        vector<string> userRawCoordinates;
        cout << "Enter your coordinates by pressing \"F3 + C\" in the direction of the launched Ender Eye:" << '\n';
        do {
            if (OpenClipboard(nullptr)) {
                HANDLE hClipboardData = GetClipboardData(CF_TEXT);
                if (hClipboardData != nullptr) {
                    char* memData = static_cast<char*>(GlobalLock(hClipboardData));
                    if (memData != nullptr) {
                        smatch regexMatches;
                        string clipboardText(memData);
                        if (
                            regex_match(clipboardText, regexMatches, regex(REGEX_PATTERN)) &&
                            find(userRawCoordinates.begin(), userRawCoordinates.end(), regexMatches[1]) == userRawCoordinates.end()
                        ) {
                            userRawCoordinates.push_back(regexMatches[1]);
                            cout << userRawCoordinates.size() << "st coordinate: " << regexMatches[1] << '\n';
                        }
                        GlobalUnlock(hClipboardData);
                    }
                }
                CloseClipboard();
            }
            Sleep(SLEEP_TIME);
        } while (userRawCoordinates.size() < MAX_ALLOWED_ENDER_EYE_THROWS);
        return userRawCoordinates;
    }

    void processUserRawCoordinates(const vector<string> userRawCoordinates) {
        for (const auto& userRawCoordinate : userRawCoordinates) {
            double currentX, currentY, currentZ, currentH, currentV;
            stringstream ss(userRawCoordinate);

            ss >> currentX >> currentY >> currentZ >> currentH >> currentV;
            x.push_back(currentX);
            y.push_back(currentY);
            z.push_back(currentZ);
            h.push_back(currentH);
            v.push_back(currentV);
        }
    }
};

double calculateDistanceToStronghold() {
    Coordinates coordinates;
    auto& x = coordinates.x;
    auto& z = coordinates.z;
    auto& h = coordinates.h;

    vector<double> slopes;
    for (size_t i = 0; i < h.size(); i++) {
        double angle = -1 * h[i] * (M_PI / 180);
        double slope = tan(angle);
        slopes.push_back(slope);
    }

    double strongholdZ = ((z[0] * slopes[0]) - (z[1] * slopes[1]) + x[1] - x[0]) / (slopes[0] - slopes[1]);
    double strongholdX = ((strongholdZ - z[0]) * slopes[0]) + x[0];
    double distanceToStronghold = sqrt(pow(strongholdX - x[1], 2) + pow(strongholdZ - z[1], 2));

    return distanceToStronghold;
}

int main() {
    while (true) {
        cout << "Approximate distance: " << calculateDistanceToStronghold() << " blocks." << '\n';
        cout << '\n';
    }

    return 0;
}
